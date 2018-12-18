import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common'
import { HttpClient } from '@angular/common/http/src/client';

// import routing module
import { AppRoutingModule } from './app.routing';
import { AppComponent } from './app.component';

import { AboutComponent } from './about';
import { CustomersComponent} from './customers/customers.component'
//import { CustomersGridComponent} from './customers/crouter.component'
import { CustomerEditComponent} from './customers/customer-edit.component'
import { CustomerEditReactiveComponent} from './customers/customer-edit-reactive.component'

import { ManagerComponent} from './managers';
import { ManagerUpdateComponent} from './managers/manager-update/manager-update.component';
import { ManagerAddComponent} from './managers/manager-add/manager-add.component';
import { ManagerDetailComponent} from './managers/manager-detail/manager-detail.component';

import {ToursComponent, TourAddComponent, TourDetailComponent,TourUpdateComponent} from './tours';

import { ShowsComponent, ShowAddComponent } from './tours/shows';
import { ManagerService } from './managers/shared/manager.service';
import { LoginService } from './login/shared/login.service';

import { UserService } from './users/shared/user.service';
import { DataService } from './core/data.service';

import { TourService } from './tours/shared/tour.service'
import { ShowService } from './tours/shows/shared/show.service'
import { MasterDataService } from './shared/master-data.service';
import { GlobalErrorHandler } from './shared/global-error-handler';
import { ErrorLoggerService } from './shared/error-logger.service';
import { HandleHttpErrorInterceptor } from './shared/handle-http-error-interceptor';
import { WriteOutJsonInterceptor } from './shared/write-out-json-interceptor';
import { EnsureAcceptHeaderInterceptor } from './shared/ensure-accept-header-interceptor';
import { ShowSingleComponent } from './tours/shows/show-single/show-single.component';
import { UsersComponent } from './users/users.component';
import { LoginComponent } from "./login/Login.component";

@NgModule({
  declarations: [
    AppComponent,
    AboutComponent,UsersComponent,
    CustomersComponent,CustomerEditComponent,//CustomersGridComponent,CustomerEditReactiveComponent,
    ShowsComponent, ShowAddComponent, ShowSingleComponent,
    TourDetailComponent,TourAddComponent,ToursComponent,TourUpdateComponent,
    ManagerComponent, ManagerUpdateComponent, ManagerAddComponent, ManagerDetailComponent, UsersComponent, LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: EnsureAcceptHeaderInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: WriteOutJsonInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HandleHttpErrorInterceptor,
      multi: true,
    },
    GlobalErrorHandler, ErrorLoggerService, TourService, ManagerService, UserService,MasterDataService,DataService, ShowService,LoginService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule {

  constructor() {

    // automapper mappings

    automapper.createMap('TourFormModel', 'TourForCreation')
      .forSourceMember('band', (opts: AutoMapperJs.ISourceMemberConfigurationOptions) => { opts.ignore(); })
      .forSourceMember('manager', (opts: AutoMapperJs.ISourceMemberConfigurationOptions) => { opts.ignore(); })
      .forMember('bandid', function (opts) { opts.mapFrom('band'); });

    automapper.createMap('TourFormModel', 'TourWithManagerForCreation')
      .forSourceMember('band', (opts: AutoMapperJs.ISourceMemberConfigurationOptions) => { opts.ignore(); })
      .forSourceMember('manager', (opts: AutoMapperJs.ISourceMemberConfigurationOptions) => { opts.ignore(); })
      .forMember('bandid', function (opts) { opts.mapFrom('band'); })
      .forMember('managerid', function (opts) { opts.mapFrom('manager'); })

    automapper.createMap('TourFormModel', 'TourWithShowsForCreation')
      .forSourceMember('band', (opts: AutoMapperJs.ISourceMemberConfigurationOptions) => { opts.ignore(); })
      .forSourceMember('manager', (opts: AutoMapperJs.ISourceMemberConfigurationOptions) => { opts.ignore(); })
      .forMember('bandid', function (opts) { opts.mapFrom('band'); });

    automapper.createMap('TourFormModel', 'TourWithManagerAndShowsForCreation')
      .forSourceMember('band', (opts: AutoMapperJs.ISourceMemberConfigurationOptions) => 
      { opts.ignore(); })
      .forSourceMember('manager', (opts: AutoMapperJs.ISourceMemberConfigurationOptions) => 
      { opts.ignore(); })
      .forMember('bandid', function (opts) { opts.mapFrom('band'); })
      .forMember('managerid', function (opts) { opts.mapFrom('manager'); })

      automapper.createMap('ShowCollectionFormModelShowsArray', 
      'ShowCollectionForCreation');

      automapper.createMap('TourFormModel', 'TourForUpdate');
  }
}
