import { Component, OnInit } from '@angular/core';
import { LoginVM } from '../login-vm';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
//import { HttpClient } from 'selenium-webdriver/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model = new LoginVM("", "");
  log = false;
  user = "";
  

  constructor(private service: AuthService, private jwtHelper: JwtHelperService) { }

  ngOnInit() {
    if (this.jwtHelper.isTokenExpired(localStorage.getItem('token'))) { this.log = false; }
    else {
    this.log = true;
    this.user = localStorage.getItem('user')}
  }

  onSubmit(form: NgForm) {
    console.log(this.model);
    this.service.login(this.model)
      .subscribe(result => {
        console.log(result)
      },
      error => {
        console.log(error)
      });
    form.reset();
    //window.location.reload();
  }

  logOut() {
    this.service.logout();
    window.location.reload();
  }

}
