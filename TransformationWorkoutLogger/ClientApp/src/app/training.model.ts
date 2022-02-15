import { Schedule } from "./schedule.model";
import { TrainingVideo } from "./trainingvideo.model";

export class Training {


  ID: string = '';
  TrainerID: string = '';

  MediaTop: boolean = true;
  MediaBottom: boolean = false;
  MediaLeft: boolean = false;
  MediaRight: boolean = false;
  MediaLink: string = '';
  Height: number = 0;
  Width: number = 0;
  Text: string = '';
  PostedDate: Date = new Date(1900, 1, 1);
  TrainingSchedule: Schedule[] = [];
  TrainingVideos: TrainingVideo[] = [];
  Image: boolean = false;
  Video: boolean = false;

  constructor(ID: string, 

    MediaTop: boolean, MediaBottom: boolean, MediaLeft: boolean, MediaRight: boolean, Image: boolean, Video:boolean,
    MediaLink: string, Height: number, Width: number, Text: string, PostedDate: Date, TrainerID: string, TrainingSchedule: Schedule[], TrainingVideos: TrainingVideo[]) {

    this.Image = Image;
    this.Video = Video;
    this.ID = ID;
    this.TrainerID = TrainerID;
    this.TrainingSchedule = TrainingSchedule;
    this.TrainingVideos = TrainingVideos;

  


    this.MediaTop = MediaTop;
    this.MediaBottom = MediaBottom;
    this.MediaLeft = MediaLeft;
    this.MediaRight = MediaRight;
    this.MediaLink = MediaLink;
    this.Height = Height;
    this.Width = Width;
    this.Text = Text;
    this.PostedDate = PostedDate;
  }
}
