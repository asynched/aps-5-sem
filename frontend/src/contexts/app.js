import createBox from 'blackbox.js'

export const appBox = createBox({
  user: null,
  messages: [],
  users: [],
})

export const appMutations = {
  /**
   * # setUser
   *
   * Sets the current 'logged-in' user.
   *
   * @param { string } user User to set in the context.
   */
  setUser(user) {
    appBox.set((state) => {
      state.user = user
      return state
    })
  },
  /**
   * # setUsers
   *
   * Sets the current active users for the session.
   *
   * @param { Array<Object> } users Users to set in the session.
   */
  setUsers(users) {
    appBox.set((state) => {
      state.users = users

      return state
    })
  },
  /**
   * # pushMessage
   *
   * Appends a new message to the end of the current messages within the context.
   *
   * @param { Object } message Message to append to the current messages context.
   */
  pushMessage(message) {
    appBox.set((state) => {
      state.messages = [...state.messages, message]
      return state
    })
  },
}
