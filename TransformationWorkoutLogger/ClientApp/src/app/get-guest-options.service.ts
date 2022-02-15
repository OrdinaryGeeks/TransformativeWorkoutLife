import { HttpClient, HttpResponse } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Admin } from './admin.model';

const restUrl = 'https://transformativeworkoutloggerapi.azurewebsites.net/api/';

@Injectable({
  providedIn: 'root'
})

export class GetGuestOptionsService {

  Admins: Admin[] = [];





  constructor(private httpClient: HttpClient) { }

  @Output() getAdminsSuccess: EventEmitter<Admin[]> = new EventEmitter<Admin[]>();
  getAdmins() {

    this.httpClient.get<Admin[]>('https://www.ordinarygeeks.com/levricksherbiary/api/bioBlurbs/')
      .pipe(map((admins) => {

        for (let admin of (admins as Array<any>)) {
          this.Admins.push({
            ID: admin.id,
            IsSuperAdmin: admin.isSuperAdmin,
            Name: admin.name,
            IsValidated: admin.isValidated,
            FBLink: admin.fbLink,
            IGLink: admin.igLink,
            SCLink: admin.scLink,
            YTLink: admin.ytLink,
            MediaTop: admin.mediaTop,
            MediaBottom: admin.mediaBottom,
            MediaLeft: admin.mediaLeft,
            MediaRight: admin.mediaRight,
            MediaLink: admin.mediaLink,
            Image: admin.image,
            Video: admin.video,
            Height: admin.height,
            Width: admin.width,
            Text: admin.text,
            PostedDate: admin.postedDate

          });

        }
      }
      )).subscribe(
        x => {
          console.log("Admins loaded"); this.getAdminsSuccess.emit(this.Admins);
        }
      )


  }
}
