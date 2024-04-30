import { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import React from 'react';


const Lobby = ({ joinRoom }) => {
    const [user, setUser] = useState("");

    return (
        <Form className='lobby'
                 onSubmit={e => {
                     e.preventDefault();
                     joinRoom(user);
                     localStorage.setItem("user", user);
                 }} >
        <Form.Group>
            <Form.Control placeholder="name" onChange={e => setUser(e.target.value)} />
        </Form.Group>
        <Button variant="success" type="submit" disabled={ !user }>Join</Button>
    </Form>
        );
}

export default Lobby;