// import logo from './logo.svg';
import './App.css';
import React, { Component }  from 'react';
import {Home} from './Home';
import {Hostel} from './Hostel';
import {Student} from './Student';

import {BrowserRouter, Route, Routes,NavLink} from 'react-router-dom';


function App() {
  return (
    <BrowserRouter>
    <div className="App container">
      <h3 className="d-flex justify-content-center m-3">
        Student And Their Residence Detail
      </h3>
        
      <nav className="navbar navbar-expand-sm bg-light navbar-dark">
        <ul className="navbar-nav">
        {/* <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/hostelTemp">
              Hosteltemp
            </NavLink>
          </li> */}
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/home">
              Home
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/Hostel">
             Hostel
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/Student">
             Students
            </NavLink>
          </li>
        </ul>
      </nav>

      <Routes>
      {/* <Route path='/hostelTemp' element={<JsonDataDisplay/>}/> */}
        <Route path='/home' element={<Home/>}/>
        <Route path='/Hostel' element={<Hostel/>}/>
        <Route path='/Student' element={<Student/>}/>
      </Routes>
    </div>
    </BrowserRouter>
  );
}

export default App;