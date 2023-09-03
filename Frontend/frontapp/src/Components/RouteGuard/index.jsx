import React from 'react';
import jwt_decode from "jwt-decode";
import { Navigate } from 'react-router-dom';


const RouteGuard = ({children, permission}) => {
 
    const getToken = () => {
        let storageValue = localStorage.getItem("token");

        if(storageValue == null){
            return null;
        }

        let token = storageValue;
        return jwt_decode(token);
    }

    const verifyToken = (token) => {
        if(!token){
            return false;
        }

        if (Date.now() >= token.exp * 1000) {
            localStorage.removeItem('token');
            return false;
        }

        if(!token[permission]){
            return false;
        }

        return true;
    }

    const  hasValidJWT = () => {
        let token = getToken();
        return verifyToken(token);
    }

   return hasValidJWT() 
        ? children
        : <Navigate to={{ pathname: '/' }} />
};
 
export default RouteGuard;