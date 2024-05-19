// @ts-ignore
import React, {createContext, useContext} from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import {BrowserRouter} from "react-router-dom";
import {UserStore} from "./stores/userStore.ts";

export const UserContext = createContext(new UserStore());

ReactDOM.createRoot(document.getElementById('root')!).render(
    <UserContext.Provider value={new UserStore()}>
    <BrowserRouter>
        <App/>
    </BrowserRouter>
    </UserContext.Provider>,
)
