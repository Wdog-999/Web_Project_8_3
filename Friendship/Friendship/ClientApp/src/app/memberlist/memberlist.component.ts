import { Component, OnInit } from '@angular/core';
import { UsersService } from '../services/users.service';
import { UserDetails } from '../models/user-details';

@Component({
  selector: 'app-memberlist',
  templateUrl: './memberlist.component.html',
  styleUrls: ['./memberlist.component.css']
})
export class MemberlistComponent implements OnInit {
  myGridOptions: any;
  users: any;
  user: any;

  constructor(private service: UsersService) {

    this.service.getUsers()
      .subscribe(_users => {
        this.myGridOptions = _users as UserDetails[];
        console.log(_users);
        this.users = _users;
        console.log(this.users);
        this.user = JSON.parse(localStorage.getItem('user'));
        console.log(this.user);
        var index = this.users.findIndex(x => x.name === this.user);
        console.log(index);
        this.users.splice(index, 1);
        var index = this.users.findIndex(x => x.name === this.user.toLowerCase());
        console.log(index);
        this.users.splice(index, 1);
        console.log(this.users)
      });
  }

  

  ngOnInit() {
    
  }

}