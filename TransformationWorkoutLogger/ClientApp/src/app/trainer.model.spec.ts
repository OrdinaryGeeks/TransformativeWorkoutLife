import { Trainer } from './trainer.model';

describe('Trainer', () => {
  it('should create an instance', () => {
    expect(new Trainer('', '', false, false, false, false, false, false, false, '', 0, 0, '', new Date(), '', [])).toBeTruthy();
  });
});
