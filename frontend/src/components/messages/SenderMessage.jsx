import React from 'react'
import { motion } from 'framer-motion'
import { getUserImage } from '@/services/images'

/**
 * # SenderMessage
 *
 * A message component that is specific for the current 'logged-in' user.
 *
 * @param { Object } props Props for the component.
 * @returns { JSX.Element } A UI component for the current user message.
 */
export default function SenderMessage({ message }) {
  return (
    <motion.div
      initial="hidden"
      animate="visible"
      variants={{
        hidden: {
          y: 24,
          opacity: 0,
        },
        visible: {
          y: 0,
          opacity: 1,
        },
      }}
      transition={{ duration: 0.5 }}
      className="flex items-start gap-4"
    >
      <div
        className="ml-auto rounded-b-2xl rounded-tl-2xl bg-message-purple py-3 px-4"
        key={message.id}
      >
        <p>{message.message}</p>
      </div>
      <img
        className="h-8 w-8 rounded-full"
        src={getUserImage(message.user)}
        alt={message.user}
      />
    </motion.div>
  )
}
