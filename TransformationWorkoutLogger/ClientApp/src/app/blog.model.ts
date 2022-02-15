import { Blurb } from "./blurb.model";

export class Blog {

  ID: string = '';
  TitleHeader: string = '';
  Blurbs: Blurb[] = [];
  GuestID: string = '';

  constructor(ID: string, TitleHeader: string, Blurbs: Blurb[], GuestID: string) {

    this.ID = ID;
    this.TitleHeader = TitleHeader;
    this.Blurbs = Blurbs;
    this.GuestID = GuestID;

  }
}
