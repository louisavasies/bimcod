import * as React from 'react';
import './HomePage.css';
import Navbar from './Navbar';
import { Link } from 'react-router-dom';



class HomePage extends React.Component<any, any> {
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <div className="homepage-container">
                <Navbar/>
                <div className="container">
                    <div className="row">
                        <p className="begin">Begin your journey with us.</p>
                        <p className="begin">Add a new car or select an existent one.</p>
                    </div>
                    <div className="row">
                        <Link to="/addcar">
                            <button className="addcar-button">
                                Add a new car
                            </button>
                        </Link>
                    </div>
                    <div className="row">
                        <Link to="/mycars">
                            <button className="selectcar-button">
                                Select car
                            </button>
                        </Link> 
                    </div>
                </div>
            </div>
        );
    }
}

export default HomePage;