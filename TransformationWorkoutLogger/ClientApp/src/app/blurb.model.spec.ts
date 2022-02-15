import { Blurb } from './blurb.model';

describe('Blurb', () => {
  it('should create an instance', () => {
    expect(new Blurb('', false, false, false, false, '', 0, 0, '', '', new Date())).toBeTruthy();
  });
});
