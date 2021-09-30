import React from 'react';
import './App.css';
import { Service } from './service/service';
import { ServiceGlobalContext } from './service/context';
import { Layout } from './layout/Layout';
import { BrowserRouter } from 'react-router-dom';

function App() {

  const service = React.useState(() => new Service())[0];

  return (
    <BrowserRouter>
      <ServiceGlobalContext.Provider value={service}>
        <Layout />
      </ServiceGlobalContext.Provider>
    </BrowserRouter >
  );
}

export default App;
