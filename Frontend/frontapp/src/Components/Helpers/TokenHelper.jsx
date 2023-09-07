import jwt_decode from "jwt-decode";

export const GetToken = () => {
    let storageValue = localStorage.getItem("token");

    if(!storageValue){
        return null;
    }

    let token = storageValue;

    if(!token){
        return false;
    }

    return `Bearer ${token}`;
};

export const GetDecodedToken = () => {
    let storageValue = localStorage.getItem("token");

    if(!storageValue){
        return null;
    }

    let token = storageValue;
    return jwt_decode(token);
}