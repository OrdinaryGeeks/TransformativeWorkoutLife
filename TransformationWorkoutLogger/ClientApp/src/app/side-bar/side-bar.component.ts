import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {
  showSideBar: boolean = true;
  constructor() { }

  ngOnInit() {
  }

  sideBarClasses() {
    if (this.showSideBar) {

      return {
        'sideNavigation': true
      }
    }
    else
      return {
        'sideNavigation': true
      }
  }
  toggleSideBarOnClick() {
    if (this.showSideBar)
      this.showSideBar = false;
    else
      this.showSideBar = true;
  }
}
