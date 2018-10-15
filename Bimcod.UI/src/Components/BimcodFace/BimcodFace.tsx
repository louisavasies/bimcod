import * as React from 'react';

import './BimcodFace.css';
import Logo from '../Logo/Logo';
import SignUpButton from '../Buttons/SignUpButton/SignUpButton';
import LoginButton from '../Buttons/LoginButton/LoginButton';

class BimcodFace extends React.Component<{}, any> {
    constructor(props: any) {
        super(props);
    }

        public render() {
            return(
                <div className="container">
                    <div className="row">
                        <Logo/>
                    </div>
                    <div className="row">
                        <SignUpButton/>
                    </div>
                    <div className="row">
                        <LoginButton/>
                    </div>
                    <div className="row">
                        <div className="credentials">
                            Credits:   Louisa Vasies
                        </div>
                    </div>
                </div>
            );
        }
}

export default BimcodFace;