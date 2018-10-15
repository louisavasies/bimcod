import * as React from 'react';
import './LoginButton.css';
import { Link } from 'react-router-dom';

class LoginButton extends React.Component<any, any> {
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <Link to="/login">
            <button className="login-button" onClick={this.props.click}>
                    login
                </button>
            </Link>
        );
    }
}

export default LoginButton;
