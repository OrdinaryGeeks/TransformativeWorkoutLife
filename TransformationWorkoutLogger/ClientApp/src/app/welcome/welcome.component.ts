import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Guest } from '../guest.model';
import { Schedule } from '../schedule.model';
import { SignupService } from '../signup.service';
import { Training } from '../training.model';
import { TrainingVideo } from '../trainingvideo.model';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {

  emailAddress: string = '';
  isGuest: boolean = true;
  isSignedUpGuest: boolean = false;
  isAdmin: boolean = false;
  isTrainer: boolean = false;
  isMerchant: boolean = false;
  guest: Guest;
  showAdminSignUp: boolean = false;

  //Admin

  nameFromFrontEnd: string = '';

  fbLink: string = '';
  igLink: string = '';
  scLink: string = '';
  ytLink: string = '';
  adminIsValidated: boolean = false;
  adminIsSuperAdmin: boolean = false;

  //AdminBlurb
  adminBlurbOrientation: string = '';
  adminBlurbMediaLink: string = '';
  adminBlurbWidth: number = 0;
  adminBlurbHeight: number = 0;
  adminBlurbImage: boolean = true;
  adminBlurbVideo: boolean = false;
  adminBlurbTop: boolean = true;
  adminBlurbBottom: boolean = false;
  adminBlurbLeft: boolean = false;
  adminBlurbRight: boolean = false;
  adminBlurbMediaType: string = '';
  adminBlurbText: string = '';
  adminBlurbBioID: number = 1;
  adminBlurbTitle: string = '';
  adminImage: boolean = false;
  adminVideo: boolean = false;

  adminMediaType: number = 0;
  adminOrientation: number = 0;

  //Trainer
  trainerTrainingPages: Training[] = [];
  trainerName: string = '';
  trainerIsValidated: boolean = false;

 //TrainerBLurb
  trainerBlurbOrientation: string = '';
  trainerBlurbMediaLink: string = '';
  trainerBlurbWidth: number = 0;
  trainerBlurbHeight: number = 0;
  trainerBlurbImage: boolean = true;
  trainerBlurbVideo: boolean = false;
  trainerBlurbTop: boolean = true;
  trainerBlurbBottom: boolean = false;
  trainerBlurbLeft: boolean = false;
  trainerBlurbRight: boolean = false;
  trainerBlurbMediaType: string = '';
  trainerBlurbText: string = '';
  trainerBlurbBioID: number = 1;
  trainerBlurbTitle: string = '';
  trainerImage: boolean = false;
  trainerVideo: boolean = false;

  trainerMediaType: number = 0;
  trainerOrientation: number = 0;


  //Training
  trainingTrainingSchedule: Schedule[] = [];
  trainingTrainingVideos: TrainingVideo[] = [];
  trainingTrainerID: string = '';
  //training Blurb
  trainingBlurbOrientation: string = '';
  trainingBlurbMediaLink: string = '';
  trainingBlurbWidth: number = 0;
  trainingBlurbHeight: number = 0;
  trainingBlurbImage: boolean = true;
  trainingBlurbVideo: boolean = false;
  trainingBlurbTop: boolean = true;
  trainingBlurbBottom: boolean = false;
  trainingBlurbLeft: boolean = false;
  trainingBlurbRight: boolean = false;
  trainingBlurbMediaType: string = '';
  trainingBlurbText: string = '';
  trainingBlurbBioID: number = 1;
  trainingBlurbTitle: string = '';
  trainingImage: boolean = false;
  trainingVideo: boolean = false;

  trainingMediaType: number = 0;
  trainingOrientation: number = 0;

  //trainingVideo
  trainingVideoTrainingID: string = '';
  Back: boolean = false;
  Chest: boolean = false;
  Biceps: boolean = false;
  Triceps: boolean = false;
  Shoulders: boolean = false;
  ForeArms: boolean = false;
  Abs: boolean = false;
  Buttocks: boolean = false;
  Quadriceps: boolean = false;
  Hamstrings: boolean = false;
  Calves: boolean = false;

  //trainingVideoBlurb
  trainingVideoBlurbOrientation: string = '';
  trainingVideoBlurbMediaLink: string = '';
  trainingVideoBlurbWidth: number = 0;
  trainingVideoBlurbHeight: number = 0;
  trainingVideoBlurbImage: boolean = true;
  trainingVideoBlurbVideo: boolean = false;
  trainingVideoBlurbTop: boolean = true;
  trainingVideoBlurbBottom: boolean = false;
  trainingVideoBlurbLeft: boolean = false;
  trainingVideoBlurbRight: boolean = false;
  trainingVideoBlurbMediaType: string = '';
  trainingVideoBlurbText: string = '';
  trainingVideoBlurbBioID: number = 1;
  trainingVideoBlurbTitle: string = '';
  trainingVideoImage: boolean = false;
  trainingVideoVideo: boolean = false;

  trainingVideoMediaType: number = 0;
  trainingVideoOrientation: number = 0;

  GuestSignUpSubscription: any;
  constructor(private signUpService: SignupService, private router: Router) {


    if (signUpService.checkGuestSignedUp()) {

      alert("Guest already signed up");

      this.isSignedUpGuest = true;
      this.isGuest = true;

      if (signUpService.checkGuestIsAdmin()) {

        this.isAdmin = true;
      }
      else
        this.isAdmin = false;
      
    }

    else {

      this.isGuest = true;
      this.isSignedUpGuest = false;
      this.isAdmin = false;
    }

    //automatically sign guests up to the isSignedUpGuest
    signUpService.getGuest().subscribe((success) => { console.log(success); this.isSignedUpGuest = true; },
      (error) => (alert(error)),
      () => (
        console.log("signupserviceggsub complete"))
      );



    this.GuestSignUpSubscription = this.signUpService.getGuestSuccess.subscribe(emailAddress => { this.emailAddress = emailAddress; this.isGuest = true; });

  }

  enterMemberArea() {
    this.router.navigateByUrl("/guest");
  }
  guestSignUp() {

    //this.signUpService.guestSignUp();

    if (this.signUpService.guestSignUp()) {
      this.isSignedUpGuest = true;
    }
    else
      alert("Error signing up guest");


  }

  toggleAdminSignUp() {

    if (this.showAdminSignUp)
      this.showAdminSignUp = false;
    else
      this.showAdminSignUp = true;

  }

  adminSignUp() {
    if (this.signUpService.checkGuestIsAdmin()) {

      this.isAdmin = true;
    }
    else {

      if (this.signUpService.adminSignUp(this.signUpService.emailAddressString, this.nameFromFrontEnd, this.fbLink, this.igLink,
        this.scLink, this.ytLink, this.adminBlurbTop, this.adminBlurbBottom, this.adminBlurbLeft,
        this.adminBlurbRight, this.adminBlurbMediaLink, this.adminBlurbHeight, this.adminBlurbWidth,
        this.adminBlurbText, this.adminImage, this.adminVideo))
      {
        this.isAdmin = true;
        alert("Is Admin True");
      }


      else
        this.isAdmin = false;

    }
     


  }
  enterTrainerArea() {

  }
  enterGuestArea() {

  }
  enterMerchantArea() {

  }

  trainerSignUp() {

    //this.signUpService.guestSignUp();

    this.isTrainer = true;
  }

  merchantSignUp() {

    //this.signUpService.guestSignUp();

    this.isMerchant = true;
  }
  ngOnInit() {
  }

}
