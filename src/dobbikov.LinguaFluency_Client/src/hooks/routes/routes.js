import React from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';

import { Container } from 'reactstrap';

import { MainPage } from "../../pages/MainPage/mainPage";
import { AuthPage } from "../../pages/AuthPage/authPage";

export const useRoutes = (isAuth) => {
    return(
        <Container>
            
            <IsUserAuth isAuth={isAuth}/>
            <IsUserUnAuth isAuth={isAuth}/>

            {isAuth == true ?
                <Redirect to="/main"/> :
                <Redirect to="/auth"/>
            }
        </Container>
    )
}

export const IsUserAuth = ({isAuth}) => {
    if(isAuth === false)
        return null;
    return(
        <Container>
            <Route path="/main" component={MainPage}/>
        </Container>
    )
}
export const IsUserUnAuth = ({isAuth}) => {
    if(isAuth === true)
        return null;
    return(
        <Container>
            <Route path="/auth" component={AuthPage}/>
        </Container>
    )
}