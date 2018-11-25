import { Component, OnInit } from '@angular/core';
import { LoginVM } from '../login-vm';
import { NgForm } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { PasswordValidator } from './password.directive';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

  model = new LoginVM("", "");
  posted = false;
  submitted = false;

  constructor(private service: AuthService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    console.log(this.model);
    this.service.postRegister(this.model)
      .subscribe(result => {
        console.log(result)
        this.posted = true;
        this.submitted = true;
      },
        error => {
          console.log(error)
          this.posted = false;
          this.submitted = true;
        });
    form.reset();
  }

}
