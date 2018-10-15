import * as React from 'react';
import './Intro.css';
import logo from 'src/media/logo-transparent.png';

class Intro extends React.Component<any, any> {
    constructor(props: any) {
        super(props);
    }

    public componentWillMount(){
        setTimeout(() => { 
            this.props.history.push('/bimcod');
        }, 5000)
    }

    public render() {
        return (
        <div className="main-container">
                <div className="row">
                    <div className="intro-container">
                        <div className="c1">Eleganta. </div>              
                    </div>
                <div className="row">
                    <div className="intro-container">
                        <div className="c2">Rafinament.</div>
                    </div>                
                </div>
                <div className="row">
                    <div className="intro-container">
                        <div className="c3">Putere.</div>
                    </div>                
                </div>
                {/* <Logo/> */}
                <div className="container">
                    <img src={logo} className="logo-image"/>
                </div>
            </div>
        </div>
        );
    }
}

export default Intro;