import * as React from 'react';
import './LoginFormComponent.css';
import IInputData from 'src/entities/IInputData';
import FormComponent from '../FormComponent/FormComponent';
import Checkbox from '../Buttons/Checkbox/Checkbox';


class LoginFormComponent extends FormComponent {
  constructor(props: any) {
    super(props);
  }

  public render() {
    return (
      <div className="login-form-component-container form-body container-fluid">
        {this.state.inputs.map((input: IInputData) => this.renderInput(input))}
        <div className="forget-remember col-xs-12">
          <a href="/forgot" className="forget-pass">forgot password</a>
          <div className="custom-control custom-checkbox-login">
            <Checkbox
                labelText="REMEMBER ME"
                labelClassNames={["remember-me-checkbox"]}
                inputId="rememberMe"
                inputOptions={{
                    name: "rememberMe"
                }}
            />
          </div>
        </div>
        <button disabled={!this.state.isValid} className="submit-button" onClick={this.submitDataHandler}>submit</button>
      </div>
    );
  }
}

export default LoginFormComponent;