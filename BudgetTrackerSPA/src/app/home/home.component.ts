import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/services/user.service';
import { UserInfo } from '../shared/models/userModel';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  users!:UserInfo[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {

    this.userService.GetAllUsers().subscribe(
      u => {
        this.users = u;
        console.log('inside home component init method');
        console.table(this.users);
      }
    );
  }

}
