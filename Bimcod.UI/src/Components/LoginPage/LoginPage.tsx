import * as React from 'react';
import './LoginPage.css';
import HttpService from '../../services/HttpService';
import { apiUrl } from '../../constants';
import { loginValidator } from '../../entities/Validation/validators';
import { loginRules } from '../../entities/Validation/rules';
import LoginFormComponent from '../LoginFormComponent/LoginFormComponent';
import StorageService from '../../services/StorageService';
import { Redirect } from 'react-router-dom';

interface ILoginCredentials {
  email: string;
  password: string;
}

class LoginPage extends React.Component<any, any> {
    private httpService: any = new HttpService();
    private storageService: StorageService = new StorageService();
    private readonly apiAddress: string = apiUrl;
    private readonly apiSessionAddress: string = "api/session";

    constructor(props: any) {
      super(props);
  
      this.state = {
        showErrorMessage: false,
        serverErrorMessage: "",
        redirect: false,
        serverMessage: "",
        checkbox: false
      };
    }
  
    public componentDidMount() {
      const remember: boolean =
        this.storageService.getItem("remember") === "true" ? true : false;
      const tokenExists: boolean = this.storageService.itemExists("token");
  
      if (remember && tokenExists) {
        this.setState({ redirect: true });
      }
    }
  
    public checkboxClickedHandle = () => {
      const checkboxChange: boolean = !this.state.checkbox;
      this.setState({ checkbox: checkboxChange });
      this.storageService.saveItem("remember", checkboxChange.toString());
    };
  
    public onLogInSuccess = (result: any) => {
      const loginToken: string = result.data.token;
      this.storageService.saveItem("token", loginToken);
      this.setState({ redirect: true });
    };
  
    public userDataHandler = (url: string, formData: any) => {
      if (!url || !formData) {
        return;
      }
  
      const body: ILoginCredentials = {
        email: formData.Email,
        password: formData.Password
      };
  
      console.log(body);
      console.log(this.apiAddress + this.apiSessionAddress);


      this.httpService
        .post(this.apiAddress + this.apiSessionAddress, body)
        .then((result: any) => this.onLogInSuccess(result))
        .catch((error: any) => this.onLogInError(error));
    };
  
    public onLogInError = (error: any) => {
      this.setState({ showErrorMessage: true });
      if (error.response === undefined) {
        this.setState({
          serverErrorMessage:
            "Could not connect to the server. Please try again later"
        });
      } else {
        if (error.response.status === 404) {
          this.setState({
            serverErrorMessage: "Email or Password incorrect. Please try again"
          });
        }
        if (error.response.status === 400) {
          this.setState({
            serverErrorMessage: "Please confirm your account first"
          });
        }
      }
      setTimeout(
        () =>
          this.setState({
            showErrorMessage: false,
            serverErrorMessage: ""
          }),
        5000
      );
    };
  
    public postSuccesful = (response: any) => {
      const loginToken: string = response.data.token;
      this.storageService.saveItem("token", loginToken);
      this.setState({
        redirect: true
      });
    };
  
    public postError = (error: any) => {
        this.showErrorMessage(error);
    };

    public render() {
      if (this.state.redirect) {
        return <Redirect push={true} to="/home" />;
      }
        return (
          <div className="register-form gif-container">
            <div className="container">
              <div className="row">
                  <div className="login-form-container">
                    {this.state.showErrorMessage ? (
                      <div className="message server-message">
                        {this.state.serverErrorMessage}
                      </div>
                    ) : null}
                    <LoginFormComponent
                      inputs={[
                        {
                          id: "user-email",
                          type: "email",
                          label: "Email",
                          errorMessage: "",
                          name: "Email",
                          value: ""
                        },
                        {
                          id: "user-password",
                          type: "password",
                          label: "Password",
                          errorMessage: "",
                          name: "Password",
                          value: ""
                        }
                      ]}
                      url={this.apiAddress}
                      buttonName=""
                      onSubmit={this.userDataHandler}
                      validator={loginValidator}
                      validationRules={loginRules}
                    />
                  </div>
                </div>
            </div>
          </div>
        );
      }


      private showErrorMessage = (error: any) => {
        this.setState({ showErrorMessage: true });
        if (error.response === undefined) {
          this.setState({
            serverErrorMessage:
              "Could not connect to the server. Please try again later"
          });
        } else {
          if (error.response.status === 404) {
            this.setState({
              serverErrorMessage: "Username or Password incorrect. Please try again"
            });
          }
          if (error.response.status === 400) {
            this.setState({
              serverErrorMessage: "Please confirm your account first"
            });
          }
        }
        setTimeout(
          () =>
            this.setState({
              showErrorMessage: false,
              serverErrorMessage: ""
            }),
          5000
        );
      };
}

export default LoginPage;