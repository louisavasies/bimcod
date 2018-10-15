import * as React from 'react';
import './Navbar.css';
import logo from 'src/media/logo-transparent.png';

class Navbar extends React.Component<any, any> {
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <div className="navbar-container">
                <div className="page">
                <header tabIndex={0}> 
                    <img src={logo} className="bimcod"/>
                </header>
                <div id="nav-container">
                    <div className="bg"/>
                    <div className="button" tabIndex={0}>
                    <span className="icon-bar"/>
                    <span className="icon-bar"/>
                    <span className="icon-bar"/>
                    </div>
                    <div id="nav-content" tabIndex={0}>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li><a href="/addcar">Add a car</a></li>
                        <li><a href="#0">My Cars</a></li>
                        <li><a href="#0">About</a></li>
                        <li><a href="#0">Contact</a></li>
                        <li className="small"><a href="#0">Facebook</a><a href="#0">Instagram</a></li>
                    </ul>
                    </div>
                </div>

                <main>
                    <div className="content">
                        <h2>I couldn't find the sports car of my dreams, so I built it myself.  <span>  Ferdinand Porsche</span></h2>
                        <p>We do everything by heart. We do it for you.</p>
                    </div>
                </main>
                </div>
            </div>
        );
    }
}

export default Navbar;
