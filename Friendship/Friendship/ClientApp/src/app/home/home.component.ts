import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { MemberlistComponent } from '../memberlist/memberlist.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private service: AuthService, private jwtHelper: JwtHelperService) { }

  log = false;

  ngOnInit() {
    if (this.jwtHelper.isTokenExpired(localStorage.getItem('token'))) { this.log = false; }
    else {
      this.log = true;
    }

  }
}
