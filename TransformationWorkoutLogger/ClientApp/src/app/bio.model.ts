import { Blurb } from "./blurb.model";

export class Bio {

  ID: string = "";
  FBLink: string = "";
  IGLink: string = '';
  SnapLink: string = '';
  YoutubeLink: string = '';
  Blurbs: Blurb[] = [];
  GuestID: string = '';

  constructor(ID: string, GuestID:string, FBLink: string, IGLink: string, SnapLink: string, YoutubeLink: string, Blurbs: Blurb[]) {

    this.GuestID = GuestID;
    this.ID = ID;
    this.FBLink = FBLink;
    this.IGLink = IGLink;
    this.SnapLink = SnapLink;
    this.YoutubeLink = YoutubeLink;
    this.Blurbs = Blurbs;
  }
}
