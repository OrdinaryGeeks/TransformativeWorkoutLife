import { Training } from './training.model';

describe('Training', () => {
  it('should create an instance', () => {
    expect(new Training('', false, false, false, false, false, false, '',0,0,'', new Date(), '', [], []    )).toBeTruthy();
  });
});
