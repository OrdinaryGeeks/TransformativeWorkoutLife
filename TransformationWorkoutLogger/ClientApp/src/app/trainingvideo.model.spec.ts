import { TrainingVideo } from './trainingvideo.model';

describe('Trainingvideo', () => {
  it('should create an instance', () => {
    expect(new TrainingVideo('', false, false, false, false, '', 0, 0, false, false, '', new Date(), '')).toBeTruthy();
  });
});
