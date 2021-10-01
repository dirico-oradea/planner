import React from 'react';
import { Link } from 'react-router-dom';
import { User } from '../models/User';
import { ServiceGlobalContext } from '../service/context';
import { observer } from 'mobx-react-lite';
import { Grid } from '@mui/material';

export const Header = observer(() => {
    const service = React.useContext(ServiceGlobalContext);

    return (
        <Grid container direction='column'>
            <Grid item>
                <span>header - example for <b>react context + global service</b> and <b>Material UI</b> components</span>
            </Grid>
            <Grid item>
                {/* this is same than a div with display flex, justify-content: center, align-item: center */}
                {/* in grid container should be grid item, check in website: https://mui.com/ */}
                <Grid container spacing={2} justifyContent='center' alignItems='center'>
                    <Grid item>
                        <Link to="/">Home</Link>
                    </Grid>
                    <Grid item>
                        <Link to="/dashboard">Dashboard</Link>
                    </Grid>
                    <Grid item>
                        <Link to="/hotels">Hotel List</Link>
                    </Grid>                    
                </Grid>
            </Grid>
            <Grid item>
                <button onClick={() => service.setCurrentUser({} as User)}>click here for login</button>
                {service.currentUser && (<div>logged</div>)}
            </Grid>
        </Grid>
    );
});