import * as React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import SignUpPage from "./Components/SignUpPage/SignUpPage";
import './App.css';
import BimcodFace from "./Components/BimcodFace/BimcodFace";
import LoginPage from "./Components/LoginPage/LoginPage";
import Intro from "./Components/Intro/Intro";
import HomePage from "./Components/HomePage/HomePage";
import AddCar from "./Components/HomePage/AddCar";


class App extends React.Component<{}, {}> {
  constructor(props: any) {
    super(props);
  }

  public render() {
    return (
      <div>
        <BrowserRouter>
          <div className="App">
            <Switch>
              <Route exact={true} path="/" component={Intro}/>
              <Route exact={true} path="/bimcod" component={BimcodFace}/>
              <Route exact={true} path="/signup" component={SignUpPage}/>
              <Route exact={true} path="/login" component={LoginPage}/>
              <Route exact={true} path="/homepage" component={HomePage}/>
              <Route exact={true} path="/addcar" component={AddCar}/>
            </Switch>
          </div>
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
