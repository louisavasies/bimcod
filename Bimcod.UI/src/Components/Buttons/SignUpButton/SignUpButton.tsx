import * as React from 'react';
import './SignUpButton.css';
import { Link } from 'react-router-dom';

class SignUpButton extends React.Component<any, any> {
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <Link to="/signup">
                <button className="signup-button">
                    sign up
                </button>
            </Link>
        );
    }

}

export default SignUpButton;
