/**
 * # getUserImage
 *
 * Helper function to get a user avatar with a given username.
 *
 * @param { string } username Username to get the random image for.
 * @returns { string } URL of an avatar for the user.
 */
export const getUserImage = (username) => {
  return `https://avatars.dicebear.com/api/identicon/${username}.svg`
}
