import { Component, OnInit } from '@angular/core';
import { UsersService } from '../services/users.service';
import { UserDetails } from '../models/user-details';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-memberdetails',
  templateUrl: './memberdetails.component.html',
  styleUrls: ['./memberdetails.component.css']
})
export class MemberdetailsComponent implements OnInit {
  user: any;
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
      });
  }

  ngOnInit() {
  }

}
