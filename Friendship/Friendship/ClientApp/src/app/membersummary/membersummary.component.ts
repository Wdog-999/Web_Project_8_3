import { Component, OnInit, Input } from '@angular/core';
import { UserDetails } from '../models/user-details';

@Component({
  selector: 'app-membersummary',
  templateUrl: './membersummary.component.html',
  styleUrls: ['./membersummary.component.css']
})
export class MembersummaryComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  @Input() user: UserDetails;

}
