import React, { useState } from 'react'
import { AnimatePresence } from 'framer-motion'
import { useBox } from 'blackbox.js'

import { preventDefault } from '@/lib/ui/modifiers'
import { appBox, appMutations } from '@/contexts/app'

import UserCard from '@/components/users/UserCard'
import { PaperAirplaneIcon } from '@heroicons/react/outline'
import MessagesContainer from '@/components/messages/MessagesContainer'

const socket = new WebSocket(import.meta.env.VITE_APP_WEBSOCKET_URL)

socket.onmessage = (rawMessage) => {
  const message = JSON.parse(rawMessage.data)

  switch (message.type) {
    // Handles the event of a server message
    // appending it to the context.
    case 'CONNECTION':
    case 'DISCONNECTION':
    case 'MESSAGE': {
      return appMutations.pushMessage(message.data)
    }

    // Handles the event of a revalidation of
    // the current active clients for the session.
    case 'CONNECTED_CLIENTS': {
      return appMutations.setUsers(message.data)
    }

    // Handles the event of the server passing the
    // front-end a name, setting it in the context
    // as the 'user' for the context.
    case 'REGISTRATION': {
      return appMutations.setUser(message.data.username)
    }
  }
}

/**
 * # IndexPage
 *
 * Index page for the app.
 *
 * @returns { JSX.Element } Root page for the application.
 */
export default function IndexPage() {
  const app = useBox(appBox)
  const [message, setMessage] = useState('')

  const handleSubmit = () => {
    socket.send(message)
    setMessage('')
  }

  return (
    <div className="flex h-screen w-full bg-gradient-to-bl from-background-initial to-background-end text-neutral-300">
      <nav className="flex max-h-screen w-64 flex-col gap-4 overflow-auto border-r border-gray-800 p-8 2xl:w-96">
        <h1 className="text-4xl font-bold tracking-tighter">Active users</h1>
        <AnimatePresence>
          {app.users.map((user) => (
            <UserCard user={user} key={user.id} />
          ))}
        </AnimatePresence>
      </nav>
      <main className="mx-auto h-full w-[80%] max-w-screen-md">
        <MessagesContainer />
        <form
          className="mx-4 mt-auto flex h-20 items-center"
          onSubmit={preventDefault(handleSubmit)}
        >
          <div className="mx-auto flex flex-1 gap-4 rounded-2xl border border-gray-800 py-3 px-6">
            <input
              type="text"
              placeholder="Your message..."
              className="w-full bg-transparent outline-none"
              value={message}
              onChange={(e) => setMessage(e.target.value)}
            />
            <button
              type="submit"
              aria-label="Send message"
              title="Send message"
            >
              <PaperAirplaneIcon className="h-6 w-6 text-gray-700" />
            </button>
          </div>
        </form>
      </main>
    </div>
  )
}
