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
      <hr />
      <h1>Fun Fact!</h1>
      <p>Title: {title}<br/>Fact: {fact}</p>
      <div>Sources: {sources?.map((value, index, sources) => (
        <p key={index} ><a href={String(value)}>{value}</a><br/></p>
      ))}</div>
    </div>
  )
}

interface FactListProps {
  facts: Array<FactData> | undefined
}
const FactList: React.FC<FactListProps> = ({facts}) => {
  const factComponents = facts?.map((fact, index, facts) => (
    <Fact factData={fact} />
  ));
  return (
    <div>
      {factComponents}
    </div>
  )
}

function App() {
  const [currentState, setCurrentState] = useState(0);

  const [data, setData] = useState<Array<FactData>>();
  const [randomFact, setRandomFact] = useState<FactData>();

  useEffect(() => {
    // Mounted
  }, []);

  const clickRandomFact = () => {
    axios({
      method: 'get',
      url: 'http://localhost:64120/get/randomfact'
    }).then(function(response) {
      const factData: FactData = response.data;
      setRandomFact(factData);
    });

    setCurrentState(1);
  }

  const clickAllFacts = () => {
    axios({
      method: 'get',
      url: 'http://localhost:64120/get/facts'
    }).then(function(response) {
      const data = response.data;
      const index = Math.floor(Math.random() * data.length);
      const randomFact: FactData = data[index];
      setRandomFact(randomFact);
      setData(data);
    });
    setCurrentState(2);
  }

  return (
    <div className="App">
      <header className="App-header">
        <p>
          Random Science Facts API! (V1)
        </p>
        <div style={{display: "flex", flexWrap: "wrap"}}>
          <button onClick={clickRandomFact} style={{margin: 30, fontSize: 22}}>Random Fact</button>
          <button onClick={clickAllFacts} style={{margin: 30, fontSize: 22}}>All Facts</button>
        </div>
        {currentState == 1 && <Fact factData={randomFact}></Fact>}
        {currentState == 2 && <FactList facts={data}></FactList>}
      </header>
    </div>
  );
}

export default App;
