import { Component, OnInit } from '@angular/core';
import { Admin } from '../admin.model';
import { GetGuestOptionsService } from '../get-guest-options.service';

@Component({
  selector: 'app-guest-page',
  templateUrl: './guest-page.component.html',
  styleUrls: ['./guest-page.component.css']
})
export class GuestPageComponent implements OnInit {

  adminsToChooseFrom: Admin[] = [];
  getAdminsSubscription: any;
  constructor(private getGuestOptionsService: GetGuestOptionsService) {


    this.getAdminsSubscription = this.getGuestOptionsService.getAdminsSuccess.subscribe(p => { this.adminsToChooseFrom = p } );


  }

  ngOnInit() {
  }

}
