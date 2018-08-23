import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from "./shared/user.model";
import {TourService} from "../tours/shared/tour.service"
import {UserService} from "./shared/user.service"


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  title: string;
  users: User[] = [];
  search: string;
  pageSize: number = 10;
  
  constructor(private dataService: UserService){}
  ngOnInit() {
    this.search='';
  //  this.getUsers();
  }
  getUsers() {
    this.dataService.getUsers()
        .subscribe((response: User[]) => {
          this.users = response;
        },
        (err: any) => console.log(err),
        () => console.log('getusers() retrieved users'));
  }
  SearchClicked()
  {
    this.dataService.getSearchUsers(this.search)
      .subscribe((response: User[]) => {
        this.users = response;
    },
    (err: any) => console.log(err),
    () => console.log('getusers() retrieved users'));
     this.search='';
  }
  // updateUser(user : User)
  // {
  //   this.dataService.updateUser(user)
  //    .subscribe((response: any) => {

  //    },
  //    (err: any) => console.log(err),
  //    () => console.log('update user'));
  // }
}