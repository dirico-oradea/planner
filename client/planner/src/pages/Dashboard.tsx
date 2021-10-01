import React from "react";
import { ServiceGlobalContext } from "../service/context";

// example how to handle redirect when user should not be in this page
export const Dashboard = () => {

    const service = React.useContext(ServiceGlobalContext);
    React.useEffect(() => {
        // if user not logged in then redirect
        if (!service.currentUser) {
            setTimeout(() => {
                return service.redirect('/');
            }, 5000);
        }
    }, [service]);

    return (
        <p>
            Dashboard - after <b>5 second</b> will be redirected because user should have no access for this page
        </p>
    );
}
