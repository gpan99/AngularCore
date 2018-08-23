import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Manager } from "../shared/manager.model";
import {TourService} from "../tours/shared/tour.service"
import {ManagerService} from "./shared/manager.service"

@Component({
  selector: 'app-managers',
  templateUrl: './managers.component.html',
  styleUrls: ['./managers.component.css']
})
export class ManagerComponent implements OnInit {
  private managers: Manager[] = [];
  constructor(private dataService: ManagerService) { }
  
  ngOnInit() {
    this.getManagers();
  }
  getManagers() {
    this.dataService.getManagers()
        .subscribe((response: Manager[]) => {
          this.managers = this.managers = response;
         
        },
        (err: any) => console.log(err),
        () => console.log('getmanagers() retrieved managers'));
  }
  updateManager(manager : Manager)
  {
    this.dataService.updateManager(manager)
     .subscribe((response: any) => {

     },
     (err: any) => console.log(err),
     () => console.log('update manager'));
  }
  deleteManager(id : string)
  {
    this.dataService.deleteManager(id)
    .subscribe((response: any) => {
    },
    (err: any) => console.log(err),
    () => console.log('delete manager'));
  }
  getManager(id : string)
  {
    this.dataService.getManager(id)
    .subscribe((response: Manager) => {
    },
    (err: any) => console.log(err),
    () => console.log('get manager'));
  }
}
