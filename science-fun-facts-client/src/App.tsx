import React, { useEffect, useState } from 'react';
import axios from 'axios';
import logo from './logo.svg';
import './App.css';

interface FactData {
  title: String,
  fact: String,
  sources: Array<String>
}

interface FactProps {
  factData: FactData |  undefined
}
const Fact: React.FC<FactProps> = ({factData}) => {
  const title = factData?.title;
  const fact = factData?.fact;
  const sources: Array<String>|undefined = factData?.sources;

  return (
    <div>
      <h1>Fun Fact!</h1>
      <p>Title: {title}<br/>Fact: {fact}</p>
      <p>Sources: {sources}</p>
    </div>
  )
}

function App() {

  const [response, setResponse] = useState<Object>();
  const [randomFact, setRandomFact] = useState<FactData>();

  useEffect(() => {
    axios({
      method: 'get',
      url: 'http://localhost:64120/get/facts'
    }).then(function(response) {
      const data = response.data;
      const index = Math.floor(Math.random() * data.length);
      const randomFact: FactData = data[index];
      setRandomFact(randomFact);
      setResponse(response);
    });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <p>
          Random Science Facts API! (V1)
        </p>
        <p>
          {/* {JSON.stringify(response)} */}
        </p>
        <Fact factData={randomFact}></Fact>
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
