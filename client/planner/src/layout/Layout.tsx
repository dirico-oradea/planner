import React from 'react';
import { Switch, Route, Link } from 'react-router-dom';
import { User } from '../models/User';
import { ServiceGlobalContext } from '../service/context';
import { observer } from 'mobx-react-lite';

const HomePage = () => (<p>Home Page</p>);
const Dashboard = () => (<p>Dashboard</p>);

const Header = observer(() => {
    const service = React.useContext(ServiceGlobalContext);

    return (
        <>
            <button onClick={() => service.setCurrentUser({} as User)}>login dummy button</button>
            <h1>header</h1>
            {service.currentUser && (<a>logged</a>)}
            <Link to="/">Home</Link>
            <Link to="/dashboard">Dashboard</Link>
        </>
    );
});

export const Layout = () => {
    return (
        <>
            <Header />
            <main>
                <Switch>
                    <Route exact path="/">
                        <HomePage />
                    </Route>
                    <Route path="/dashboard">
                        <Dashboard />
                    </Route>
                </Switch>
            </main>
        </>
    );
};