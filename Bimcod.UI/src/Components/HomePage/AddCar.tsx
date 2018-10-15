import * as React from 'react';
import './AddCar.css';
import Navbar from './Navbar';


class AddCar extends React.Component<any, any> {
    constructor(props: any) {
        super(props);

    }

    public render() {
        return (
            <div className="homepage-container">
                <Navbar/>
                <div className="cars-container">
                    <div className="row">
                        <div className="addcar-container">
                            <label className="model">E90</label>
                            <button className="e90"/>
                        </div>
                        <div className="addcar-container">
                            <label className="model">E91</label>
                            <button className="e91"/>
                        </div>
                        <div className="addcar-container">
                            <label className="model">E92</label>
                            <button className="e92"/>
                        </div>
                    </div>
                    <div className="row">
                        <div className="addcar-container">
                            <label className="model">E93</label>
                            <button className="e93"/>
                        </div>
                        <div className="addcar-container">
                            <label className="model">F30</label>
                            <button className="f30"/>
                        </div>
                        <div className="addcar-container">
                            <label className="model">F31</label>
                            <button className="f31"/>
                        </div>
                    </div>
                    <div className="row">
                        <div className="addcar-container">
                            <label className="model">F34</label>
                            <button className="f34"/>
                        </div>
                        <div className="addcar-container">
                            <label className="model">E60</label>
                            <button className="e60"/>
                        </div>
                        <div className="addcar-container">
                            <label className="model">E61</label>
                            <button className="e61"/>
                        </div>
                    </div>
                    <div className="row">
                        <div className="addcar-container">
                            <label className="model">F10</label>
                            <button className="f10"/>
                        </div>
                        <div className="addcar-container">
                            <label className="model">F11</label>
                            <button className="f11"/>
                        </div>
                        <div className="addcar-container">
                            <label className="model">F07</label>
                            <button className="f07"/>
                        </div>
                    </div>

                    <div className="row">
                        <div className="type-container">
                            <button className="type"> NFL </button>
                            <button className="type"> LCI </button>
                        </div>
                    </div>
                    <div className="row">
                        <div className="addcarbutton-container">
                            <button className="addcarbutton"> ADD CAR </button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default AddCar;