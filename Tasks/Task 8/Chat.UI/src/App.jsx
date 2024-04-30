import {useState} from 'react';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import Lobby from './components/Lobby.jsx';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Chat from "./components/Chat.jsx";
import './index.css';
import React from 'react';

const App = ()  => {
  const [connection, setConnection] = useState();
  const [messages, setMessages] = useState([]);
  const [isConnected, setIsConnected] = useState(false);

  const joinRoom = async (user) => {
    try {
      const connection = new HubConnectionBuilder()
          .withUrl("https://localhost:44379/GeneralHub")
          .configureLogging(LogLevel.Information)
          .build();

      connection.on("ReceiveMessage", (user, message, id) => {
          setMessages(messages => [...messages, {user, message, id}]);
      });

      connection.on("DisconnectUser", (connectionId) => {
        setUsers(users.filter((value, index, self) =>
            index === self.findIndex((t) => (
                t.connectionId === value.connectionId
            ))));
        setUsers(users.filter(x => x.connectionId !== connectionId));
      })

      connection.onclose(e => {
        setConnection();
        setMessages([]);
        setUsers([]);
        setIsConnected(false);
      });

      await connection.start();
      await connection.invoke("JoinRoom", { userName: user });
      setConnection(connection);
      setIsConnected(true);
    } catch (e) {
      console.log(e);
    }
  }

  if(localStorage.getItem("user") !== null && !isConnected) {
    setIsConnected(true);
    joinRoom(localStorage.getItem("user"));
  }

  const sendMessage = async (message) => {
    try {
      await connection.invoke("SendMessage", { userName: localStorage.getItem("user"), messageContent: message });
    } catch (e) {
      console.log(e);
    }
  }

  const closeConnection = async () => {
    try {
      setIsConnected(false);
      await connection.stop();
      localStorage.removeItem("user");
    } catch (e) {
      console.log(e);
    }
  }

  if(!isConnected || localStorage.getItem("user") === null)
    return (
        <>
          <h2>MyChat</h2>
          <hr className='line'/>
          <Lobby joinRoom={joinRoom}/>
        </>
    );

    return (
        <>
          <Chat sendMessage={sendMessage} messages={messages} closeConnection={closeConnection}/>
        </>
    );
}

export default App
