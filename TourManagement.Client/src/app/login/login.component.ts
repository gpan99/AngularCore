import { Component, OnInit } from '@angular/core';
import {LoginService} from "./shared/login.service";
import {Login} from "./shared/login.model";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit 
{
  //constructor(private loginService: LoginService) { }
  constructor(private loginService: LoginService){}

  errorMessage: string = "";
  public creds = {
    username: "",
    password: ""
  };
  ngOnInit() {
    var search='sf x';
    //  this.getUsers();
    }
    onLogin()
    {
     // this.dataService.login(this.creds);
      
      console.log('username='+this.creds.username);
    }
}
