import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthorizeService } from '../api-authorization/authorize.service';
import { Admin } from './admin.model';
import { Bio } from './bio.model';
import { Blog } from './blog.model';
import { Guest } from './guest.model';


const restUrl = 'https://transformativeworkoutloggerapi.azurewebsites.net/api/';
@Injectable({
  providedIn: 'root'
})
export class SignupService {
  //Guest
  emailAddressString: string = "";
  emailFromResponse: string = "";
  guest: Guest = new Guest('');
  getGuestResponse: HttpResponse<Guest>;

  currentDate :Date= new Date();

  //Admin
  adminIDFromFrontEnd: string = '';
  adminBio: Bio = new Bio('', '', '', '', '', '', []);
  adminBlog: Blog = new Blog('', '', [], '');
  adminName: string = '';
  adminIsValidated: boolean = false;
  adminIsSuperAdmin: boolean = false;
  adminIdFromResponse: string = "";


  constructor(private httpClient: HttpClient, private authorizeService: AuthorizeService) {

    this.authorizeService.getUser().pipe(map(u => u && u.name)).subscribe(userNameFromAuth => this.emailAddressString = userNameFromAuth);

    this.authorizeService.isAuthenticated().subscribe(u => {

      this.getGuest().subscribe((response: HttpResponse<Guest>) => {

        this.emailFromResponse = response.body.id;
        this.getGuestResponse = {
          body: response.body, status: response.status, statusText: response.statusText, type: response.type,
          headers: response.headers, clone: response.clone, url: response.url, ok: response.ok
        };
        if (response.status == 200 && response.body.id == "blank@ordinarygeeks.com") {
          alert("No User Was Found");

        //  this.guestSignUp();
        }
      }, (error) => { console.log("error ", error) },
        () => {
          alert("get Guest Subscription Complete");
        }
      );

    },
      (error) => { console.log("isAuthenticated subscription error") },
      () => { alert("Is authenticated subscription finished") });

  }

  checkGuestIsAdmin(): boolean {

    this.getAdmin().subscribe((response: HttpResponse<Admin>) => {
      console.log(response);

      this.adminIdFromResponse = response.body.ID;

      if (this.adminIdFromResponse != "")
        return true;
      else
        return false;
    });

    return false;

  }

  checkGuestSignedUp(): boolean {



    this.getGuest().subscribe((response: HttpResponse<Guest>) => {
      console.log(response);
      this.emailFromResponse = response.body.id;
     


      if (this.emailFromResponse != "blank@ordinarygeeks.com")
        return true;
      else
        return false;
    })

    return false;
 
  }
  @Output() getGuestSuccess: EventEmitter<string> = new EventEmitter<string>();
  getGuest() :Observable<HttpResponse<Guest>> {

    return this.httpClient.get<Guest>(restUrl + "guests/" + this.emailAddressString, { observe: 'response' });
    
  }
  guestSignUp(): boolean  {

    alert("GSU");
    var headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    var postAddGuestJson = JSON.stringify({
      id: this.emailAddressString
    })

    this.httpClient
      .post<any>(restUrl + 'guests/', postAddGuestJson, { headers }).subscribe(success => { alert('guestAdded'); this.getGuestSuccess.emit(this.emailAddressString); return true; }, error => { alert('error adding guest') });


    return false;
  }

  getAdmin(): Observable<HttpResponse<Admin>> {

    return this.httpClient.get<Admin>(restUrl + "admins/" + this.emailAddressString, { observe: 'response' });

  }

  getDate(): string {

 

    return new Date().toISOString();
  }
  adminSignUp(nameFromFrontEnd: string, adminName:string, fbLink: string, igLink: string, scLink: string,
    ytLink: string, MediaTop: boolean, MediaBottom: boolean, MediaLeft: boolean, MediaRight: boolean,
    MediaLink: string, Height: number, Width: number, Text: string, Image:boolean, Video:boolean) : boolean {

    alert("ASU");
    var headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    var postUpgradeToAdminJson = JSON.stringify({
      id: this.emailAddressString,
      name: adminName,
      isValidated: this.adminIsValidated,
      isSuperAdmin: this.adminIsSuperAdmin,
      image: Image,
      video: Video,
      fbLink: fbLink,
      igLink: igLink,
      scLink: scLink,
      ytLink: ytLink,
      MediaTop: MediaTop,
      MediaBottom: MediaBottom,
      MediaLeft: MediaLeft,
      MediaRight: MediaRight,
      MediaLink: MediaLink,
      Height: Height,
      Width: Width,
      Text: Text,
      PostedDate: this.getDate()


    })

    this.httpClient
      .post<any>(restUrl + 'admins/', postUpgradeToAdminJson, { headers }).subscribe(success => { alert('guest signed up for admin'); return true; }, error => { alert('error upgrading guest to admin') });
    return false;

  }
}
