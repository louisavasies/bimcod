import * as React from 'react';
import './Logo.css'
import logo from 'src/media/logo-transparent.png';

class Logo extends React.Component<any, any> {
  constructor(props: any) {
    super(props);
  }


  public render() {
    return (
        <img src={logo} className="logo-img"/>
    );
  }
}

export default Logo;