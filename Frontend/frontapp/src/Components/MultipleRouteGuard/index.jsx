import React from 'react';
import { Navigate } from 'react-router-dom';

const MultipleRouteGuard = ({children, permissions}) => {

    const hasValidToken = () => {
        let token = JSON.parse(localStorage.getItem("permissions"));
        if(!token){
            return false;
        }

        if (Date.now() >= token.exp * 1000) {
            localStorage.removeItem('token');
            return false;
        }

        if(!Object.keys(token).some(x => permissions.includes(x))){
            return false;
        }

        return true;
    }

   return hasValidToken()
        ? children
        : <Navigate to={{ pathname: '/' }} />
};
 
export default MultipleRouteGuard;