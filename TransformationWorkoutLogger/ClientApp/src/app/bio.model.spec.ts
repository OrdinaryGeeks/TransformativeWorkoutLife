import { Bio } from './bio.model';

describe('Bio', () => {
  it('should create an instance', () => {
    expect(new Bio('', '', '', '', '', '', [])).toBeTruthy();
  });
});
