import * as React from 'react';
import './SignUpPage.css'
import FormComponent from 'src/Components/FormComponent/FormComponent';
import IUserDto from '../../entities/IUserDto';
import { Redirect } from 'react-router-dom';
import {signUpRules} from '../../entities/Validation/rules';
import {signUpValidator} from '../../entities/Validation/validators';
import HttpService from '../../services/HttpService';
import {apiUrl} from 'src/constants';
import StorageService from '../../services/StorageService';


const signupFormBody: any = [
    {id: 'user-name', type: 'text', label: 'username', errorMessage: '', name: 'Username', value: ''},
    {id: 'user-email', type: 'email', label: 'email', errorMessage: '', name: 'Email', value: ''},
    {id: 'user-password', type: 'password', label: 'password', errorMessage: '', name: 'Password', value: ''},
    {id: 'user-confpass', type: 'password', label: 'confirm Password', errorMessage: '', name: 'ConfPassword', value: ''}
]

class SignUpPage extends React.Component<{}, any> {
   private httpService: any = new HttpService();
   private storageService: StorageService = new StorageService();

   constructor(props: any) {
      super(props);

      this.state = {
        showErrorMessage: false,
        serverErrorMessage: '',
        redirect: false,
        loginRedirect: false
      }
   }


  public userDataHandler = (url: string, formData: any) => {
    if(!url || !formData){
        return;
    }

    const comp: any = this;

    const body: IUserDto = {id: -1, username: formData.Username, password: formData.Password, email: formData.Email};

    console.log(url);
    console.log(body);

    this.httpService.post(url, body)
    .then((res: any) => {
        const emailUrl: string  = apiUrl + "api/email/" + res.data.id; 
        this.httpService.get(emailUrl);
        comp.setState({
            redirect: true
        });
    })
    .catch((error: any) => {
        if(!error){
            comp.setState({
                serverMessage: "Couldn't connect to the server"
            });
            return;
        };
        comp.setState({
            serverMessage: error.response.data
        });
        setTimeout(()=>comp.setState({
            serverMessage: ''
        }), 5000);  
    });
  }

    public postSuccesful = (response: any) => {
        const loginToken: string = response.data.token;
        this.storageService.saveItem('token', loginToken);
        this.setState({
            loginRedirect: true
        });
    }

    public postError = (error: any) => {
        this.showErrorMessage(error);
    }

   public render() {
      if(this.state.redirect){
        return (<Redirect push={true} to="/login"/>);
      }
      return (
            <div className="gif-container">
               <div className="row">
                  <div>
                     <div className="signup-form-container">
                        {this.state.showErrorMessage ? (<div className="message server-message">{this.state.serverErrorMessage}</div>) : null}
                        <FormComponent className="signup-form" inputs={signupFormBody}
                           url={apiUrl + "api/users"}
                           buttonName=""
                           onSubmit={this.userDataHandler}
                           validator={signUpValidator}
                           validationRules={signUpRules}
                        />
                     </div>
                  </div>
               </div>
            </div>
      );
   }

   private showErrorMessage = (error: any) =>{
    this.setState({ showErrorMessage: true });
    if (error.response === undefined) {
        this.setState({ serverErrorMessage: "Could not connect to the server. Please try again later" });
    }
    else {
        if (error.response.status === 404) {
            this.setState({ serverErrorMessage: "Username or Password incorrect. Please try again" });
        }
        if (error.response.status === 400) {
            this.setState({ serverErrorMessage: "Please confirm your account first" });
        }
    }
    setTimeout(() => this.setState({
        showErrorMessage: false,
        serverErrorMessage: ''
    }), 5000);
    }
}

export default SignUpPage;
