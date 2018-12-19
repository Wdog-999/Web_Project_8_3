import { Component, OnInit } from '@angular/core';
import { UsersService } from '../services/users.service';
import { UserDetails } from '../models/user-details';
import { UserEdit } from '../models/useredit';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-memberedit',
  templateUrl: './memberedit.component.html',
  styleUrls: ['./memberedit.component.css']
})
export class MembereditComponent implements OnInit {
  user: UserDetails;
  changes: UserEdit;
  id: string;

  constructor(private service: UsersService, private route: ActivatedRoute) {
    this.route.queryParams
      .subscribe(params => {
        console.log(params);
        this.id = params.id;
        console.log(this.id);
      });

    this.service.getUser(this.id)
      .subscribe(_user => {
        this.user = _user as UserDetails;
      });}

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    console.log(this.user);
    //this.changes.Name = this.user.Name;
    //this.changes.Interests = this.user.Interests;
    //this.changes.Introduction = this.user.Introduction;
    //this.changes.LookingFor = this.user.LookingFor;
    //console.log(this.changes);
    this.service.updateUser(this.id, this.user)
      .subscribe(result => {
        console.log(result)
      },
        error => {
          console.log(error)
      });
    window.location.reload();
  }

}
