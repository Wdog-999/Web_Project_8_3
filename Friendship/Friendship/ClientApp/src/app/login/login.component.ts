import { Component, OnInit } from '@angular/core';
import { LoginVM } from '../login-vm';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
//import { HttpClient } from 'selenium-webdriver/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model = new LoginVM("", "");
  

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    console.log(this.model);
    this.http.post('api/auth/login/', this.model)
      .subscribe(result => {
        console.log(result)
      },
      error => {
        console.log(error)
      });
    form.reset();
  }

}
