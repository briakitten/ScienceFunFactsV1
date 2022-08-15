import React, { useEffect, useState } from 'react';
import axios from 'axios';
import logo from './logo.svg';
import './App.css';

function App() {

  const [facts, setFacts] = useState([]);

  useEffect(() => {
    axios({
      method: 'get',
      url: 'http://localhost:64120/get/facts'
    }).then(function(response) {
      console.log(response.data);
    });
  }, []);


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Random Science Facts API! (V1)
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
