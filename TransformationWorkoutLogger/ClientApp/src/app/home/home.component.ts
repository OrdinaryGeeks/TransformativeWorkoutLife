import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthorizeService } from '../../api-authorization/authorize.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public isAuthenticated: boolean;
  public userName: Observable<string>;
  public isSuperAdmin: boolean = false;


  constructor(private authorizeService: AuthorizeService, private router : Router) {
    //this.authorizeService.getUser().pipe(map(u => u && u.name)).subscribe(u => this.userName = u);
    this.authorizeService.isAuthenticated().subscribe(u => {



      this.isAuthenticated = u;
      if(this.isAuthenticated)
      router.navigateByUrl("/welcome");
    })


    //this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));

    this.userName.subscribe
      (
      u =>
      {
      if (u == "testAdmin@ordinarygeeks.com") {
        this.isSuperAdmin = true;
      };
      }
      )

    
  }


  ngOnInit() {

  }
}
