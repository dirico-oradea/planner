import { Switch, Route, Redirect, useHistory } from 'react-router-dom';
import { HomePage } from '../pages/HomePage';
import { Dashboard } from '../pages/Dashboard';
import { HotelListPage } from '../pages/HotelListPage';
import { ServiceGlobalContext } from '../service/context';
import React from 'react';

export const Pages = () => {

    const service = React.useContext(ServiceGlobalContext);
    // if we not like to use the redirect element then we should use the history.push
    // we override the original redirect function with programatic redirect from useHistory hook
    service.redirect = useHistory().push;

    return (
        <main style={{ border: '1px solid #000'}}>
            <Switch>
                <Route exact path="/">
                    <HomePage />
                </Route>
                <Route path="/dashboard">
                    <Dashboard />
                </Route>
                <Route path="/dashboard">
                    <Dashboard />
                </Route>
                <Route path="/hotels" render={() => {
                    // example when we want some logic before let user enter to page
                    if (service.currentUser) {
                        alert('u are logged in');
                    } else {
                        alert('u are not logged in, we not let you to access the HoteListPage');
                        return <Redirect to='/' />
                    }
                    return <HotelListPage />
                }} />
            </Switch>
        </main>
    );
}